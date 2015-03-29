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
