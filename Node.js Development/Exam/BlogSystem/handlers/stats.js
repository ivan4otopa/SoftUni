let url = require('url')
let articles = require('../models/articles')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName === '/stats') {
    if (req.headers['my-authorization'] && req.headers['my-authorization'] === 'Admin') {
      res.writeHead(200)

      let html = '<!DOCTYPE html><html><head><title>Stats</title></head><body><ul>'
      let commentCount = 0
      let viewCount = 0

      for (let i = 0; i < articles.length; i++) {
        html += '<li><strong>Title</strong>: ' + articles[i].title + '<br />'
        html += '<strong>Description</strong>: ' + articles[i].description + '<br />'
        html += '<a href="/details/' + articles[i].id + '">Details</a></li>'
        commentCount += articles[i].comments.length
        viewCount += articles[i].viewCount
      }

      html += '</ul>'
      html += '<div><strong>Comment Count</strong>: ' + commentCount + '</div>'
      html += '<div><strong>View Count</strong>: ' + viewCount + '</div>'
      html += '</body></html>'
      res.write(html)
      res.end()
    } else {
      res.writeHead(404)
      res.write('404 Not Found')
      res.end()
    }
  } else {
    return true
  }
}
