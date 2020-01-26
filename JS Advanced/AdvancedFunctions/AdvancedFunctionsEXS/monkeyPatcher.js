function solve(action) {
    let post = this;
    let obj = (() => {

        function upvote() {
            post.upvotes++;
        }
        function downvote() {
            post.downvotes++;
        }
        function score() {
            let totalVotes = post.upvotes + post.downvotes;
            let currentUpvotes = post.upvotes;
            let currentDownvotes = post.downvotes;

            if (totalVotes > 50) {
                let numberToAdd = Math.ceil(Math.max(currentUpvotes, currentDownvotes) * 0.25);
                currentUpvotes += numberToAdd;
                currentDownvotes += numberToAdd;
            }

            let rating = '';
            let balance = currentUpvotes - currentDownvotes;

            if (post.upvotes - post.downvotes < 0 && totalVotes >= 10) {
                rating = 'unpopular';
            }
            else if (post.upvotes / totalVotes * 100 > 66 && totalVotes >= 10) {
                rating = 'hot';
            }
            else if (balance >= 0 && totalVotes > 100) {
                rating = 'controversial';
            }
            else {
                rating = 'new';
            }
            return [currentUpvotes, currentDownvotes, balance, rating];
        }
        return { upvote, downvote, score };
    })();
    return obj[action]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solve.call(post, 'upvote');
solve.call(post, 'downvote');
console.log(solve.call(post, 'score')); // [127, 127, 0, 'controversial']
for (let i = 0; i < 50; i++) {
    solve.call(post, 'downvote'); // (executed 50 times)
}
console.log(solve.call(post, 'score')); // [139, 189, -50, 'unpopular']