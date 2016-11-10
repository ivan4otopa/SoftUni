let fs = require('fs')
let url = require('url')
let articles = require('../models/articles')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName.indexOf('/details') !== -1 && req.pathName.indexOf('/comment') === -1) {
    fs.readFile('./details.html', (err, data) => {
      if (err) throw err

      let splittedUrl = req.pathName.split('/')
      let id = Number(splittedUrl[2])
      let article = articles[id]
      let linkText = ''

      if (!article.deleted) {
        linkText = 'DELETE'
      } else {
        linkText = 'UNDELETE'
      }

      article.viewCount++
      res.writeHead(200)
      res.write(data)

      let html = '<strong>Title</strong>: ' + article.title + '<br />'

      html += '<strong>Description</strong>: ' + article.description + '<br />'
      html += '<strong>View Count</strong>: ' + article.viewCount + '<br />'
      html += '<a href="/changeState/' + id + '">' + linkText + '</a>'
      html += '<form action="/details/' + id + '/comment" method="POST">'
      html += '<input type="text" name="username" /><br />'
      html += '<textarea name="comment"></textarea><br />'
      html += '<input type="submit" value="Submit" /></form>'
      html += '<h2>Comments</h2>'

      let comments = article.comments

      for (let i = 0; i < comments.length; i++) {
        html += '<div><strong>Username</strong>: ' + comments[i].username + '<br />'
        html += '<strong>Comment</strong>: ' + comments[i].comment + '</div>'
      }

      html += '<p><img src="' + article.imageUrl + '" />'

      res.write(html)
      res.end()
    })
  } else {
    return true
  }
}
