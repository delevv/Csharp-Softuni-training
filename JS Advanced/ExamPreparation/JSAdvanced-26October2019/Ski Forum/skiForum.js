class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (Array.from(arguments).includes('')) {
            throw new Error("Input can not be empty");
        }

        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }

        if (this._users.find(u => u.username === username)) {
            throw new Error("This user already exists!");
        }

        let user = {
            username,
            password,
            email,
            log: false
        }

        this._users.push(user);

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password) {
            user.log = true;
            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        let user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password) {
            user.log = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        let user = this._users.find(u => u.username === username);

        if (!user || user.log === false) {
            throw new Error("You should be logged in to post questions");
        }

        if (question === '') {
            throw new Error("Invalid question");
        }

        let newQuestion = {
            question,
            user: user.username,
            id: this._id++,
            answers: []
        }

        this._questions.push(newQuestion);
        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        let user = this._users.find(u => u.username === username);

        if (!user || user.log === false) {
            throw new Error("You should be logged in to post answers");
        }

        if (answer === '') {
            throw new Error("Invalid answer");
        }

        let question = this._questions.find(q => q.id === questionId);

        if (!question) {
            throw new Error("There is no such question");
        }

        let newAnswer = { username, answer };
        question.answers.push(newAnswer);

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        let result = '';

        this._questions.forEach(q => {
            result += `Question ${q.id} by ${q.user}: ${q.question}\n`;

            q.answers.forEach(a => {
                result += `---${a.username}: ${a.answer}\n`;
            });
        });

        return result.trim();
    }
}