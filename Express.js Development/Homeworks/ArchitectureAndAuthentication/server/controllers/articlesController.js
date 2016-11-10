let Article = require('mongoose').model('Article')
let url = require('url')
let User = require('../data/User')

module.exports = {
  getAdd: (req, res) => {
    res.render('articles/add')
  },
  list: (req, res) => {
    let page = 1
    let pageSize = 5
    let sortOrder = 1
    let query = url.parse(req.url).query

    if (query) {
      let parts = query.split('&')

      for (let part of parts) {
        let splittedCouple = part.split('=')

        if (splittedCouple[0] === 'page') {
          page = Number(splittedCouple[1])
        } else if (splittedCouple[0] === 'pageSize') {
          pageSize = Number(splittedCouple[1])
        } else {
          sortOrder = Number(splittedCouple[1])
        }
      }
    }

    Article
      .aggregate([
        { $skip: (page - 1) * pageSize },
        { $limit: pageSize },
        { $sort: { title: sortOrder } }
      ])
      .then((articles) => {
        res.render('articles/list', { articles })
      })
  },
  details: (req, res) => {
    Article
      .findById(req.params.id)
      .then((article) => {
        let currentUserIsMaker = req.user.articles.indexOf(article._id) > -1

        res.render('articles/details', { article, currentUserIsMaker })
      })
  },
  getEdit: (req, res) => {
    Article
      .findById(req.params.id)
      .then((article) => {
        res.render('articles/edit', { article })
      })
  },
  postAdd: (req, res) => {
    let articleInput = req.body
    let user = req.user

    Article
      .create({
        title: articleInput.title,
        content: articleInput.content,
        maker: user
      })
      .then((article) => {
        User
          .findByIdAndUpdate(user._id, { $push: { articles: article } })
          .exec()

        res.redirect('/')
      })
  },
  postEdit: (req, res) => {
    let articleInput = req.body

    Article
      .findByIdAndUpdate(req.params.id, { $set: { title: articleInput.title, content: articleInput.content } })
      .exec()

    res.redirect('/')
  }
}
