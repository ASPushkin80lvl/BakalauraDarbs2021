function Fibonnaci(num) {
    numbers = [];
    numbers.push('0');
    numbers.push('1');
    let n1 = 0, n2 = 1, n3;
    for (i = 2; i < num; i++)
    {
        n3 = n1 + n2;
        numbers.push(n3.toString());
        n1 = n2;
        n2 = n3;
    }
    return numbers.join(' | ');
}

'use strict';
const express = require("express");
const bodyParser = require("body-parser");
const Sequelize = require('sequelize');
const db = require("./models");

const app = express();

var port = process.env.PORT || 1337;
var sequelize = new Sequelize('postgres://postgres:29465532@localhost:5432/BakalauraDarbsDB');

app.use(bodyParser.text());
db.sequelize.sync();

app.get('/', (req, res) => {
    res.send("Benchmark test Node.js");
});

app.get('/database', (req, res) => {
    db.users.findAll({ where: { Name: 'NODE.JS' } })
        .then(data => {
            res.send(data[0].Id + ' -- ' + data[0].Name);
        });
});

app.post('/fibonnaci', (req, res) => {
    let body = '';
    req.on('data', (chunk) => {
        body += chunk;
    }).on('end', () => {
        res.send(Fibonnaci(JSON.parse(body).num));
    });
});

app.listen(port, () => {
    console.log(`Server is running on port ${port}.`);
});
