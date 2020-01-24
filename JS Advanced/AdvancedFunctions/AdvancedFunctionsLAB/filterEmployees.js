function solve(data, criteria) {
    data = JSON.parse(data);
    if (criteria !== 'all') {
        let [type, value] = criteria.split('-');
        data = data.filter(x => x[type] === value);
    }
    let counter = 0;

    for (let i = 0; i < data.length; i++) {
        console.log(`${counter++}. ${data[i]['first_name']} ${data[i]['last_name']} - ${data[i]['email']}`);
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
}, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
},
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
}]`,
    'gender-Female'
);