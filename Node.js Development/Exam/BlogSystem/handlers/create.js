let fs = require('fs')
let url = require('url')
let articles = require('../models/articles.js')
let multiparty = require('multiparty')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName === '/create') {
    let method = req.method

    fs.readFile('./createForm.html', (err, data) => {
      if (err) throw err

      if (method === 'GET') {
        res.writeHead(200)
        res.write(data)
        res.end()
      } else if (method === 'POST') {
        let exists = fs.existsSync('./images')

        if (!exists) {
          fs.mkdirSync('./images')
        }

        let form = new multiparty.Form()
        let id = articles.length
        let article = { id: id, deleted: false, viewCount: 0, comments: [] }

        form.on('part', (part) => {
          if (part.filename) {
            let imageUrl = './images/' + part.filename
            let fileExists = fs.existsSync('./images/' + part.filename)

            if (fileExists) {
              imageUrl = './images/(' + id + ')' + part.filename
            }

            let writeStream = fs.createWriteStream(imageUrl)

            part.on('data', (data) => {
              writeStream.write(data)
            })
            part.on('end', () => {
              writeStream.end()
              article['imageUrl'] = '.' + imageUrl
            })
          } else {
            let body = ''

            part.on('data', (data) => {
              body += data
            })
            part.on('end', () => {
              if (part['name'] === 'title') {
                article['title'] = body
              } else {
                article['description'] = body
              }
            })
          }
        })

        articles.push(article)
        form.parse(req)
        res.writeHead(201)
        res.write(data)
        res.write('Created')
        res.end()
      }
    })
  } else {
    return true
  }
}
