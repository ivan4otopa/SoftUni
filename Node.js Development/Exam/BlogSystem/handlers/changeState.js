let url = require('url')
let articles = require('../models/articles')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName.indexOf('/changeState') !== -1) {
    let splittedUrl = req.pathName.split('/')
    let id = Number(splittedUrl[2])
    let article = articles[id]

    if (!article.deleted) {
      article.deleted = true
    } else {
      article.deleted = false
    }

    res.writeHead(303, {
      'Location': '/all'
    })
    res.end()
  } else {
    return true
  }
}
