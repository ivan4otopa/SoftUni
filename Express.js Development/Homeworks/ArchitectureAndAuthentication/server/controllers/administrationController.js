let Article = require('../data/Article')
let User = require('../data/User')

module.exports = {
  index: (req, res) => {
    res.render('administration/index')
  },
  getEdit: (req, res) => {
    Article
      .findById(req.params.id)
      .then((article) => {
        res.render('administration/edit', { article })
      })
  },
  delete: (req, res) => {
    Article
      .findById(req.params.id)
      .then((article) => {
        User
          .findByIdAndUpdate(req.user._id, { $pop: { articles: article } })
          .then(() => {
            article.remove()
            res.redirect('/articles/list')
          })
      })
  }
}
