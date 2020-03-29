import { helper } from './help-functions.js';
import { requester } from './firebase-requests.js';

async function footerAndHeaderPartials() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.username = sessionStorage.getItem('username');
    this.loggedIn = !!sessionStorage.getItem('token');
}
async function home() {
    await footerAndHeaderPartials.call(this);
    this.partial('./templates/home/home.hbs');
}

async function about() {
    await footerAndHeaderPartials.call(this);
    this.partial('./templates/about/about.hbs');
}

async function login() {
    await footerAndHeaderPartials.call(this);
    this.partials.loginForm = await this.load('./templates/login/loginForm.hbs')
    await this.partial('./templates/login/loginPage.hbs');

    let loginForm = document.getElementById('login-form');
    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        let formData = helper.getFormInputsValuesAsObject(loginForm);
        await helper.loginUser(formData.username, formData.password);

        await checkIfUserIsInTeam();
        this.redirect('#/home');
    });
}

async function register() {
    await footerAndHeaderPartials.call(this);
    this.partials.registerForm = await this.load('./templates/register/registerForm.hbs')
    await this.partial('./templates/register/registerPage.hbs');

    let registerForm = document.getElementById('register-form');

    registerForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        let formData = helper.getFormInputsValuesAsObject(registerForm);

        if (formData.password === formData.repeatPassword) {
            await helper.registerUser(formData.username, formData.password);
            sessionStorage.setItem('hasNoTeam', true);
            this.redirect('#/home');
        }
    })
}

async function logout() {
    helper.logoutUser();
    this.redirect('#/home');
}

async function catalog() {
    await footerAndHeaderPartials.call(this);

    this.partials.team = await this.load('./templates/catalog/team.hbs')

    let token = sessionStorage.getItem('token');
    this.teams = Object.entries(await requester.getAllRecords(token).then(teams => teams || {}))
        .map(([key, value]) => ({ name: value.name, comment: value.comment, _id: key }));

    await checkIfUserIsInTeam();
    let hasNoTeam = sessionStorage.getItem('hasNoTeam');
    this.hasNoTeam = hasNoTeam === 'true';

    await this.partial('./templates/catalog/teamCatalog.hbs');

    if (this.hasNoTeam) {
        let createBtn = document.getElementById('create-team-btn');

        createBtn.addEventListener('click', () => {
            this.redirect('#/create');
        });
    }
}

async function createTeam() {
    await footerAndHeaderPartials.call(this);
    this.partials.createForm = await this.load('./templates/create/createForm.hbs');

    await this.partial('./templates/create/createPage.hbs');

    let createForm = document.getElementById('create-form');
    createForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        let team = helper.getFormInputsValuesAsObject(createForm);
        team.teamMembers = [{
            id: sessionStorage.getItem('userId'),
            username: sessionStorage.getItem('username')
        }];
        team.creator = sessionStorage.getItem('userId');

        let token = sessionStorage.getItem('token');

        await requester.createRecord(token, team);
        sessionStorage.setItem('hasNoTeam', false);

        this.redirect('#/catalog');
    });
}

async function catalogById() {
    let token = sessionStorage.getItem('token');
    this.teamId = this.params.id;

    let { comment, creator, name, teamMembers } = await requester.getRecordById(token, this.teamId);

    this.name = name;
    this.comment = comment;
    this.members = (teamMembers || []).map(member => ({ username: member.username }));

    this.isAuthor = creator === sessionStorage.getItem('userId');
    this.isOnTeam = (teamMembers || []).find(x => x.id === sessionStorage.getItem('userId'));

    await footerAndHeaderPartials.call(this);
    this.partials.teamMember = await this.load('./templates/catalog/teamMember.hbs');
    this.partials.teamControls = await this.load('./templates/catalog/teamControls.hbs');
    this.partial('./templates/catalog/details.hbs');
}

async function joinTeam() {
    checkIfUserIsInTeam();

    if (sessionStorage.getItem('hasNoTeam') === 'true') {
        let token = sessionStorage.getItem('token');
        let team = await requester.getRecordById(token, this.params.id);

        await requester.partialUpdateRecord(token, this.params.id,
            {
                teamMembers: [...(team.teamMembers || []),
                {
                    username: sessionStorage.getItem('username'),
                    id: sessionStorage.getItem('userId')
                }]
            }
        );

        this.redirect(`#/catalog/${this.params.id}`);
    }
    else {
        let infoBox = document.getElementById('infoBox');
        infoBox.textContent = 'You alredy have TEAM';
        infoBox.style.display = 'block';

        setTimeout(() => {
            infoBox.style.display = 'none';
        }, 2000)
    }
}

async function leaveTeam() {
    let token = sessionStorage.getItem('token');
    let team = await requester.getRecordById(token, this.params.id);

    await requester.partialUpdateRecord(token, this.params.id,
        {
            teamMembers: [
                ...(team.teamMembers || [])
                    .filter(m => m.id !== sessionStorage.getItem('userId'))
            ]
        }
    );

    sessionStorage.setItem('hasNoTeam', true);
    this.redirect(`#/catalog/${this.params.id}`);
}

async function editTeam() {
    await footerAndHeaderPartials.call(this);
    this.partials.editForm = await this.load('./templates/edit/editForm.hbs');
    await this.partial('./templates/edit/editPage.hbs');

    let editForm = document.getElementById('edit-form');

    let token = sessionStorage.getItem('token');

    editForm.addEventListener('submit', async e => {
        e.preventDefault();
        let formData = helper.getFormInputsValuesAsObject(editForm);

        await requester.partialUpdateRecord(token, this.params.id, formData);

        this.redirect(`#/catalog/${this.params.id}`);
    });
}

async function checkIfUserIsInTeam() {
    let token = sessionStorage.getItem('token');
    let userId = sessionStorage.getItem('userId');

    let hasNoTeam = true;
    let teams = await requester.getAllRecords(token);

    if (teams !== null && teams !== undefined) {
        Object.values(teams).forEach(team => {

            if (team.teamMembers) {
                team.teamMembers.forEach((user) => {
                    if (user.id === userId) {
                        hasNoTeam = false;
                    }
                })
            }
        });
    }

    sessionStorage.setItem('hasNoTeam', hasNoTeam);
}

export const handlers = {
    home,
    about,
    login,
    register,
    logout,
    createTeam,
    catalog,
    catalogById,
    joinTeam,
    leaveTeam,
    editTeam
}