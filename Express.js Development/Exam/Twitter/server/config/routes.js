let controllers = require('../controllers')
let auth = require('../config/auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/users/register', controllers.users.register)
  app.post('/users/create', controllers.users.create)
  app.get('/users/login', controllers.users.login)
  app.post('/users/authenticate', controllers.users.authenticate)
  app.post('/users/logout', controllers.users.logout)
  app.get('/profile/:username', auth.isAuthenticated, controllers.users.profile)

  app.get('/tweet', auth.isAuthenticated, controllers.tweets.getAdd)
  app.post('/tweet', controllers.tweets.add)
  app.get('/tweets/edit/:id', auth.isAuthenticated && auth.isInRole('Admin'), controllers.tweets.getEdit)
  app.post('/tweets/edit/:id', controllers.tweets.edit)
  app.get('/tweets/delete/:id', auth.isAuthenticated && auth.isInRole('Admin'), controllers.tweets.delete)
  app.get('/tweets/like/:id', auth.isAuthenticated, controllers.tweets.like)
  app.get('/tweets/dislike/:id', auth.isAuthenticated, controllers.tweets.dislike)
  app.get('/tag/:tagName', controllers.tweets.listTagNameTweets)

  app.get('/admins', auth.isAuthenticated && auth.isInRole('Admin'), controllers.admins.index)
  app.get('/admins/all', auth.isAuthenticated && auth.isInRole('Admin'), controllers.admins.all)
  app.get('/admins/add', auth.isAuthenticated && auth.isInRole('Admin'), controllers.admins.getAdd)
  app.post('/admins/add', controllers.admins.add)

  app.all('*', (req, res) => {
    // res.status(404).send('404 Not Found').end()
    res.status(404)
    res.send('404 Not Found')
    res.end()
  })
}
