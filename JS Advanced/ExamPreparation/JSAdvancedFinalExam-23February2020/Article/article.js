class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same article twice!");
        }

        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this article!");
        }

        let index = this._likes.indexOf(username);
        this._likes.splice(index, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id === undefined || !this._comments.find(c => c.Id === id)) {
            let comment = { Id: this._comments.length + 1, Username: username, Content: content, Replies: [] };
            this._comments.push(comment);

            return `${username} commented on ${this.title}`;
        }

        let currComment = this._comments.find(c => c.Id === id);

        let currId = Object.keys(currComment.Replies).length;

        let reply = { Id: `${id}.${currId === 0 ? 1 : currId + 1}`, Username: username, Content: content };
        currComment.Replies.push(reply)

        return "You replied successfully";
    }

    toString(sortingType) {
        let result = `Title: ${this.title}\n` +
            `Creator: ${this.creator}\n` +
            `Likes: ${this._likes.length}\n` +
            'Comments:\n';

        let sortedComments;
        if (sortingType === 'asc') {
            sortedComments = this._comments.sort((a, b) => a.Id - b.Id);
            sortedComments.forEach(c => c.Replies = c.Replies.sort((a, b) => +a.Id.split('.')[1] - +b.Id.split('.')[1]));
        }
        else if (sortingType === 'desc') {
            sortedComments = this._comments.sort((a, b) => b.Id - a.Id);
            sortedComments.forEach(c => c.Replies = c.Replies.sort((a, b) => +b.Id.split('.')[1] - +a.Id.split('.')[1]));
        }
        else if (sortingType === 'username') {
            sortedComments = this._comments.sort((a, b) => a.Username.localeCompare(b.Username));
            sortedComments.forEach(c => c.Replies = c.Replies.sort((a, b) => a.Username.localeCompare(b.Username)));
        }

        sortedComments.forEach(comment => {
            result += `-- ${comment.Id}. ${comment.Username}: ${comment.Content}\n`;

            comment.Replies.forEach(reply => {
                result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`;
            });
        });

        return result.trim();
    }
}