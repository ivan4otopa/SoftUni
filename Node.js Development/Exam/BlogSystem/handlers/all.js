let fs = require('fs')
let url = require('url')
let articles = require('../models/articles')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName === '/all') {
    fs.readFile('./all.html', (err, data) => {
      if (err) throw err

      res.writeHead(200)
      res.write(data)

      let html = '<ul>'

      for (let i = 0; i < articles.length; i++) {
        if (!articles[i].deleted) {
          html += '<li><strong>Title</strong>: ' + articles[i].title + '<br />'
          html += '<strong>Description</strong>: ' + articles[i].description + '<br />'
          html += '<a href="/details/' + articles[i].id + '">Details</a></li>'
        }
      }

      html += '</ul>'
      res.write(html)
      res.end()
    })
  } else {
    return true
  }
}
