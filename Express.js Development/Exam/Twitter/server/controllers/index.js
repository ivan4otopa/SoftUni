let homeController = require('./homeController')
let usersController = require('./usersController')
let tweetsController = require('./tweetsController')
let adminsController = require('./adminsController')

module.exports = {
  home: homeController,
  users: usersController,
  tweets: tweetsController,
  admins: adminsController
}
