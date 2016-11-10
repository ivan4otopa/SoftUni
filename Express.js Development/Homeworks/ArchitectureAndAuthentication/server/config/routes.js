let controllers = require('../controllers')
let auth = require('../config/auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)
  app.get('/about', controllers.home.about)

  app.get('/users/register', controllers.users.register)
  app.post('/users/create', controllers.users.create)
  app.get('/users/login', controllers.users.login)
  app.post('/users/authenticate', controllers.users.authenticate)
  app.post('/users/logout', controllers.users.logout)

  app.get('/articles/add', auth.isAuthenticated, controllers.articles.getAdd)
  app.post('/articles/add', controllers.articles.postAdd)
  app.get('/articles/list', controllers.articles.list)
  app.get('/articles/details/:id', auth.isAuthenticated, controllers.articles.details)
  app.get('/articles/edit/:id', auth.isMaker, controllers.articles.getEdit)
  app.post('/articles/edit/:id', controllers.articles.postEdit)

  app.get('/administration', controllers.administration.index)
  app.get('/administration/edit/:id', controllers.administration.getEdit)
  app.get('/administration/delete/:id', controllers.administration.delete)

  app.all('*', (req, res) => {
    // res.status(404).send('404 Not Found').end()
    res.status(404)
    res.send('404 Not Found')
    res.end()
  })
}
