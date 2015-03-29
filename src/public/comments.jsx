var converter = new Showdown.converter();

var data = [
    {key: 1, author: "Baba Cloanța", text: "Un comentariu obraznic"},
    {key: 2, author: "Făt Frumos", text: "Ba *muma* Dvs."},
    {key: 3, author: "Zmeul", text: "Nu știu ce să [zic](https://say.com/)"}
];

var Comment = React.createClass({
    render: function () {
        var rawMarkup = converter.makeHtml(this.props.children.toString());

        return (
            <div className="comment">
                <h2 className="commentAuthor">
                    {this.props.author}
                </h2>
                <span dangerouslySetInnerHTML={{__html: rawMarkup}} />
            </div>
        );
    }
});

var CommentList = React.createClass({
    render: function () {
        var commentNodes = this.props.data.map(function (comment) {
            return (
                <Comment key={comment.key} author={comment.author}>
                    {comment.text}
                </Comment>
            );
        });

        return (
            <div className="commentList">
                {commentNodes}
            </div>
        );
    }
});

var CommentForm = React.createClass({
    render: function () {
        return (
            <div className="commentForm">
                Aici vine formularul unde comentezi.
            </div>
        );
    }
});

var CommentBox = React.createClass({
    loadCommentsFromServer: function () {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            success: function (comments) {
                this.setState({comments: comments});
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    getInitialState: function () {
        return {comments: []};
    },
    componentDidMount: function () {
        this.loadCommentsFromServer();
        setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    },
    render: function () {
        return (
            <div className="commentBox">
                <h1>Comentarii</h1>
                <CommentList data={this.state.comments} />
                <CommentForm />
            </div>
        );
    }
});

React.render(
    <CommentBox url="comments.json" pollInterval={2000} />,
    document.getElementById('content')
);
