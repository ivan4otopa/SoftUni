let encription = require('../utilities/encryption')
let User = require('../data/User')
let Tweet = require('../data/Tweet')

module.exports = {
  register: (req, res) => {
    res.render('users/register')
  },
  create: (req, res) => {
    let user = req.body

    if (user.password !== user.confirmPassword) {
      user.globalError = 'Passwords do not match!'
      res.render('users/register', user)
    } else {
      user.salt = encription.generateSalt()
      user.hashedPass = encription.generateHashedPassword(user.salt, user.password)

      User
        .create(user)
        .then((user) => {
          req.logIn(user, (err, user) => {
            if (err) {
              res.render('users/register', { globalError: 'Ooops 500' })
            } else {
              res.redirect('/')
            }
          })
        })
    }
  },
  login: (req, res) => {
    res.render('users/login')
  },
  authenticate: (req, res) => {
    let inputUser = req.body

    User
      .findOne({ username: inputUser.username })
      .then((user) => {
        if (!user.authenticate(inputUser.password)) {
          res.render('users/login', { globalError: 'Invalid username or password' })
        } else {
          req.logIn(user, (err, user) => {
            if (err) {
              res.render('users/register', { globalError: 'Ooops 500' })
            } else {
              res.redirect('/')
            }
          })
        }
      })
  },
  logout: (req, res) => {
    req.logout()
    res.redirect('/')
  },
  profile: (req, res) => {
    let username = req.params.username

    User
      .findOne({ username: username })
      .populate({ path: 'tweets', options: { sort: { creationDate: -1 } } })
      .then((user) => {
        if (user !== null) {
          let tweets = user.tweets

          for (let i = 0; i < tweets.length; i++) {
            Tweet
              .findByIdAndUpdate(tweets[i]._id, { $inc: { viewsCount: 1 } })
              .exec()
          }

          res.render('users/profile', { user })
        } else {
          res.render('home/index', { globalError: 'User with username ' + username + ' does not exist' })
        }
      })
  }
}
