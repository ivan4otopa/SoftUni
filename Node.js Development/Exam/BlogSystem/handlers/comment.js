let url = require('url')
let articles = require('../models/articles')
let qs = require('querystring')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName.indexOf('comment') !== -1) {
    let splittedUrl = req.pathName.split('/')
    let id = Number(splittedUrl[2])
    let article = articles[id]
    let body = ''

    req.on('data', (data) => {
      body += data
    })
    req.on('end', () => {
      let dataObject = qs.parse(body)
      let username = dataObject['username']
      let comment = dataObject['comment']
      let commentObject = { username: username, comment: comment }

      article.comments.push(commentObject)
    })

    res.writeHead(303, {
      'Location': '/details/' + id
    })
    res.end()
  } else {
    return true
  }
}
