class CommentBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleCommentSubmit = this.handleCommentSubmit.bind(this);
    }
    loadCommentsFromServer() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    handleCommentSubmit(comment) {
        const data = new FormData();
        data.append('author', '');
        data.append('text', comment.Text);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadCommentsFromServer();
        xhr.send(data);
    }
    componentWillMount() {
        this.loadCommentsFromServer();
        window.setInterval(() => this.loadCommentsFromServer(), this.props.pollInterval);
    }
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentForm onCommentSubmit={this.handleCommentSubmit}/>
                <CommentList data={this.state.data} />
            </div>
            
        );
    }
}

class CommentList extends React.Component {
    render() {
        const commentNodes = this.props.data.map(comment => (
            <Comment author={comment.author} key={comment.id}>
                {comment.text}
            </Comment>
        ));
        return (
            <div className="commentList">
                {commentNodes}
            </div>
        );
    }
}

function createRemarkable() {
    var remarkable =
        'undefined' != typeof global && global.Remarkable
            ? global.Remarkable
            : window.Remarkable;

    return new remarkable();
}

class Comment extends React.Component {
    rawMarkup = () => {
        var md = createRemarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };

    };
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">
                    {this.props.author}
                </h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
            </div>
        );
    }
}


class CommentForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { author: '', text: '' };
        this.handleTextChange = this.handleTextChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleTextChange(e) {
        this.setState({ text: e.target.value });
    }
    handleSubmit(e) {
        e.preventDefault();
        const text = this.state.text.trim();
        if (!text) {
            return;
        }
        this.props.onCommentSubmit({ Author: '', Text: text });
        this.setState({ author: '', text: '' });
    }
    render() {
        return (
            <form className="commentForm" onSubmit={this.handleSubmit}>
                <input
                    type="text"
                    placeholder="Say something..."
                    value={this.state.text}
                    onChange={this.handleTextChange}
                />
                <input type="submit" value="Post" />
            </form>
        );
    }
}



ReactDOM.render(
    <CommentBox url="/comments" submitUrl="/comments/new" pollInterval={2000}/>,
    document.getElementById('content')
);