function solve(input) {
    let arena = {
        players: {},
        addPlayer: (playerInfo) => {
            let [name, technique, skill] = playerInfo;

            if (!arena.players[name]) {
                arena.players[name] = {};
            }
            if (!arena.players[name][technique]) {
                arena.players[name][technique] = 0;
            }
            if (skill > arena.players[name][technique]) {
                arena.players[name][technique] = +skill;
            }
        },
        fight: (firstName, secondName) => {
            let firstWarrior = arena.players[firstName];
            let secondWarrior = arena.players[secondName];

            if (firstWarrior && secondWarrior) {
                let canTheyFight = false;

                let firstTech = Object.keys(firstWarrior);
                let secondTech = Object.keys(secondWarrior);

                for (let technique of firstTech) {
                    if (secondTech.includes(technique)) {
                        canTheyFight = true;
                        break;
                    }
                }
                if (canTheyFight) {

                    let firstWarriorSkill = Object.values(firstWarrior).reduce((a, b) => a + b);
                    let secondWarriorSkill = Object.values(secondWarrior).reduce((a, b) => a + b);

                    if (firstWarriorSkill > secondWarriorSkill) {
                        delete arena.players[secondName];
                    }
                    else if (secondWarriorSkill > firstWarriorSkill) {
                        delete arena.players[firstName];
                    }
                }
            }
        },
        getGlatiatorTotalSkill: (name) => {
            return Object.values(arena.players[name]).reduce((a, b) => a + b);
        },
        report: () => {
            for (let [gladiatorName, gladiatorTechniques] of Object.entries(arena.players).sort(compareGladiators)) {

                console.log(`${gladiatorName}: ${arena.getGlatiatorTotalSkill(gladiatorName)} skill`);

                for (let [name, points] of Object.entries(gladiatorTechniques).sort(compareTechniques)) {

                    console.log(`- ${name} <!> ${points}`);
                }
            }
        }

    }

    for (let commandArgs of input) {
        if (commandArgs === 'Ave Cesar') {
            arena.report();
        }
        else if (commandArgs.includes(' -> ')) {
            let playerInfo = commandArgs.split(' -> ');
            arena.addPlayer(playerInfo);
        }
        else if (commandArgs.includes(' vs ')) {
            let wariors = commandArgs.split(' vs ');
            arena.fight(wariors[0], wariors[1]);
        }
    }
    function compareGladiators(a, b) {
        let firstSkill = arena.getGlatiatorTotalSkill(a[0]);
        let secondSkill = arena.getGlatiatorTotalSkill(b[0]);

        return secondSkill - firstSkill ? secondSkill - firstSkill : a[0].localeCompare(b[0]);
    };
    function compareTechniques(a, b) {
        return b[1] - a[1] ? b[1] - a[1] : a[0].localeCompare(b[0]);
    };

}

solve(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar'
]);
