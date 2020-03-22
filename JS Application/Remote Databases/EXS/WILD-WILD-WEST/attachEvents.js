function attachEvents() {
    const addPlayerBtn = document.getElementById('addPlayer');
    const playerNameInput = document.getElementById('addName');
    const playersList = document.getElementById('players');
    const playerFieldsets = document.getElementsByTagName('fieldset');

    const saveBtn = document.getElementById('save');
    const reloadBtn = document.getElementById('reload');

    const canvas = document.getElementById('canvas');

    let currentPlayer;
    let currentId;

    showPlayers();

    addPlayerBtn.addEventListener('click', addPlayer);

    saveBtn.addEventListener('click', async () => {
        await saveGame(currentId, currentPlayer);
        await showPlayers();
    });

    reloadBtn.addEventListener('click', () => {
        if (currentPlayer.money >= 60) {
            currentPlayer.money -= 60;
            currentPlayer.bullets += 6;
        }
    });

    async function addPlayer() {
        const playerInitialMoney = 500;
        const playerInitialBullets = 6;

        const player = {
            name: playerNameInput.value,
            money: playerInitialMoney,
            bullets: playerInitialBullets,
        }

        if (player.name !== '') {
            playerNameInput.value = '';

            await requests.postPlayer(player);
            await showPlayers();
        }
    }

    async function showPlayers() {
        requests.getPlayers()
            .then((players) => {
                if (players !== null && players !== undefined) {
                    playersList.innerHTML = '';

                    Object.entries(players)
                        .forEach(([id, playerInfo]) => {
                            let playerDiv = getPlayerElement(id, playerInfo);
                            playersList.appendChild(playerDiv);
                        });
                }
            });
    }

    function getPlayerElement(id, { name, money, bullets }) {
        let playerDiv = document.createElement('div');
        playerDiv.classList.add('player');
        playerDiv.setAttribute('player-id', id);

        let nameP = document.createElement('p');
        nameP.textContent = `Name: ${name}`;
        playerDiv.appendChild(nameP);

        let moneyP = document.createElement('p');
        moneyP.textContent = `Money: ${money}`;
        playerDiv.appendChild(moneyP);

        let bulletsP = document.createElement('p');
        bulletsP.textContent = `Bullets: ${bullets}`;
        playerDiv.appendChild(bulletsP);

        let playBtn = document.createElement('button');
        playBtn.classList.add('play');
        playBtn.textContent = 'Play';
        playBtn.addEventListener('click', playGame);

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deletePlayer);

        playerDiv.appendChild(playBtn);
        playerDiv.appendChild(deleteBtn);
        return playerDiv;
    }

    async function deletePlayer() {
        let id = this.parentElement.getAttribute('player-id');
        await requests.deletePlayer(id);
        await showPlayers();
    }

    async function playGame() {
        currentId = this.parentElement.getAttribute('player-id');
        let playerInfo = Array.from(this.parentElement.children)
            .filter(x => x.tagName === 'P')
            .map(x => x.textContent.split(' ')[1]);

        currentPlayer = {
            name: playerInfo[0],
            money: Number(playerInfo[1]),
            bullets: Number(playerInfo[2])
        }

        await saveGame(currentId, currentPlayer);
        loadCanvas(currentPlayer);
        displayGame(true);
        dispalyPlayersView(false);
    }

    function displayGame(state) {
        let view = state ? 'inline-block' : 'none';

        canvas.style.display = view;
        saveBtn.style.display = view;
        reloadBtn.style.display = view;
    }

    function dispalyPlayersView(state) {
        let view = state ? 'inline-block' : 'none';

        playerFieldsets[0].style.display = view;
        playerFieldsets[1].style.display = view;
    }

    async function saveGame(id, playerInfo) {
        await requests.updatePlayer(id, playerInfo);
        clearInterval(canvas.intervalId);
        displayGame(false);
        dispalyPlayersView(true);
    }
}