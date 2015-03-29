var converter = new Showdown.converter();

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
        return (
            <div className="commentList">
                <Comment author="Baba Cloanța">Un comentariu</Comment>
                <Comment author="Făt Frumos">Ba *mama* Dvs.</Comment>
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
                <CommentList />
                <CommentForm />
            </div>
        );
    }
});

React.render(<CommentBox />, document.getElementById('content'));