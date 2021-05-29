const Sequelize = require('sequelize');
const Users = require("./Users");

const sequelize = new Sequelize('BakalauraDarbsDB', 'postgres', '29465532', {
    host: 'localhost',
    port: '5432',
    dialect: 'postgres',
    operatorsAliases: false,
});

const db = {};

db.Sequelize = Sequelize;
db.sequelize = sequelize;
db.users = Users(sequelize);

module.exports = db;