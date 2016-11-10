let User = require('../data/User')

module.exports = {
  index: (req, res) => {
    res.render('admins/index')
  },
  all: (req, res) => {
    User
      .find({ roles: 'Admin' })
      .then((users) => {
        res.render('admins/all', { users })
      })
  },
  getAdd: (req, res) => {
    res.render('admins/add')
  },
  add: (req, res) => {
    User
      .findOneAndUpdate({ username: req.body.username }, { $push: { roles: 'Admin' } })
      .then((user) => {
        res.redirect('/')
      })
  }
}
