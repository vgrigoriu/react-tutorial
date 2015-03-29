var CommentList = React.createClass({
    render: function () {
        return (
            <div className="commentList">
                bau, îs lista de comentarii
            </div>
        );
    }
});

var CommentBox = React.createClass({
    render: function () {
        return (
            <div className="commentBox">
                Hola, io-s comment box
            </div>
        );
    }
});

React.render(<CommentBox />, document.getElementById('content'));
