let Tweet = require('../data/Tweet')
let User = require('../data/User')

module.exports = {
  getAdd: (req, res) => {
    res.render('tweets/add')
  },
  add: (req, res) => {
    let user = req.user
    let message = req.body.message
    let splittedMessage = message.split(/[\s.,!?]+/)
    let tags = []
    let otherUsers = []

    for (let i = 0; i < splittedMessage.length; i++) {
      let word = splittedMessage[i]

      if (word.startsWith('#')) {
        tags.push(word.substr(1))
      }

      if (word.startsWith('@')) {
        otherUsers.push(word.substr(1))
      }
    }

    Tweet
      .create({
        message: message,
        author: user,
        tags: tags
      })
      .then((tweet) => {
        User
          .findByIdAndUpdate(user._id, { $push: { tweets: tweet } })
          .then((foundSender) => {
            for (let i = 0; i < otherUsers.length; i++) {
              User
                .findOneAndUpdate({ username: otherUsers[i] }, { $push: { tweets: tweet } })
                .exec()
            }
          })

        res.redirect('/')
      })
      .catch((err) => {
        if (err) {
          console.log(err)
        }

        res.render('home/index', { globalError: 'Message must be onlt 140 symbols long' })
      })
  },
  listTagNameTweets: (req, res) => {
    Tweet
      .find({ tags: req.params.tagName })
      .sort({ creationDate: -1 })
      .then((tweets) => {
        for (let i = 0; i < tweets.length; i++) {
          Tweet
            .findByIdAndUpdate(tweets[i]._id, { $inc: { viewsCount: 1 } })
            .exec()
        }

        res.render('tweets/tagName', { tweets, tagName: req.params.tagName })
      })
  },
  getEdit: (req, res) => {
    Tweet
      .findById(req.params.id)
      .then((tweet) => {
        Tweet
          .findByIdAndUpdate(tweet._id, { $inc: { viewsCount: 1 } })
          .then(() => {
            res.render('tweets/edit', { tweet })
          })
      })
  },
  edit: (req, res) => {
    Tweet
      .findByIdAndUpdate(req.params.id, { $set: { message: req.body.message } })
      .then((tweet) => {
        res.redirect('/')
      })
  },
  delete: (req, res) => {
    Tweet
      .findById(req.params.id)
      .then((tweet) => {
        tweet.remove(req, function () {
          res.redirect('/')
        })
      })
  },
  like: (req, res) => {
    Tweet
      .findByIdAndUpdate(req.params.id, { $inc: { likesCount: 1 } })
      .then((tweet) => {
        User
          .findByIdAndUpdate(req.user._id, { $push: { likedTweets: tweet } })
          .then((user) => {
            res.redirect('/')
          })
      })
  },
  dislike: (req, res) => {
    Tweet
      .findByIdAndUpdate(req.params.id, { $inc: { likesCount: -1 } })
      .then((tweet) => {
        User
          .findByIdAndUpdate(req.user._id, { $pull: { likedTweets: tweet._id } })
          .then((user) => {
            res.redirect('/')
          })
      })
  }
}
