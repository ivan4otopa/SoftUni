let homeController = require('./homeController')
let usersController = require('./usersController')
let articlesController = require('./articlesController')
let administrationController = require('./administrationController')

module.exports = {
  home: homeController,
  users: usersController,
  articles: articlesController,
  administration: administrationController
}
