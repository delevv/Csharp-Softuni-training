function solve(kingdomsInfo, battlesInfo) {
    let kingdoms = kingdomsInfo.reduce((acc, curr) => {
        let [kingdomName, generalName, armyCount] = Object.values(curr);

        if (!acc[kingdomName]) {
            acc[kingdomName] = {};
        }
        if (!acc[kingdomName][generalName]) {
            acc[kingdomName][generalName] = {};
            acc[kingdomName][generalName].army = 0;
            acc[kingdomName][generalName].wins = 0;
            acc[kingdomName][generalName].loses = 0;
        }
        acc[kingdomName][generalName].army += armyCount;

        return acc;
    }, {});

    for (const battle of battlesInfo) {
        let [attackingKingdom, attackingGeneral, defendingKingdom, defendingGeneral] = battle;

        if (attackingKingdom !== defendingKingdom) {
            let firstGenral = kingdoms[attackingKingdom][attackingGeneral];
            let secondGenral = kingdoms[defendingKingdom][defendingGeneral];
            if (firstGenral.army > secondGenral.army) {
                firstGenral.wins++;
                secondGenral.loses++;
                firstGenral.army = Math.floor(firstGenral.army * 1.10);
                secondGenral.army = Math.floor(secondGenral.army * 0.90);
            }
            else if (secondGenral.army > firstGenral.army) {
                secondGenral.wins++;
                firstGenral.loses++;
                secondGenral.army = Math.floor(secondGenral.army * 1.10);
                firstGenral.army = Math.floor(firstGenral.army * 0.90);
            }
        }
    }

    let winningKingdom = Object.entries(kingdoms).sort((a, b) => {
        let aGeneralsWinsSum = Object.values(a[1]).reduce((acc, curr) => acc + curr.wins, 0);
        let bGeneralsWinsSum = Object.values(b[1]).reduce((acc, curr) => acc + curr.wins, 0);

        if (aGeneralsWinsSum !== bGeneralsWinsSum) {
            return bGeneralsWinsSum - aGeneralsWinsSum;
        }
        else {
            let aGeneralsLosesSum = Object.values(a[1]).reduce((acc, curr) => acc + curr.loses, 0);
            let bGeneralsLosesSum = Object.values(b[1]).reduce((acc, curr) => acc + curr.loses, 0);
            if (aGeneralsLosesSum !== bGeneralsLosesSum) {
                return aGeneralsLosesSum - bGeneralsLosesSum;
            }
            else {
                return a[0].localeCompare(b[0]);
            }
        }
    })[0];

    console.log(`Winner: ${winningKingdom[0]}`);

    for (const general of Object.entries(winningKingdom[1]).sort((a, b) => b[1].army - a[1].army)) {
        console.log(`/\\general: ${general[0]}`);
        console.log(`---army: ${general[1].army}`);
        console.log(`---wins: ${general[1].wins}`);
        console.log(`---losses: ${general[1].loses}`);
    }
}

solve([{ kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 }],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Stonegate", "Ulric", "Stonegate", "Doran"],
    ["Stonegate", "Doran", "Maiden Way", "Merek"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
    ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]
);