var converter = new Showdown.converter();

var data = [
    {key: 1, author: "Baba Cloanța", text: "Un comentariu obraznic"},
    {key: 1, author: "Făt Frumos", text: "Ba *muma* Dvs."}
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
    render: function () {
        return (
            <div className="commentBox">
                <h1>Comentarii</h1>
                <CommentList data={this.props.data} />
                <CommentForm />
            </div>
        );
    }
});

React.render(<CommentBox data={data} />, document.getElementById('content'));
