let http = require('http')
let fs = require('fs')
let qs = require('querystring')
let images = []

http
  .createServer((req, res) => {
    if (req.headers['StatusHeader'] && req.headers['StatusHeader'] === 'Full') {
      fs.readFile('status.html', (err, data) => {
        if (err) {
          res.writeHead(404)
          res.write('404 Not Found')
          res.end()

          return
        }

        let imagesCountDiv = document.getElementById('images-count')

        imagesCountDiv.innerText = images.length
        res.writeHead(200)
        res.write(data)
        res.end()

        return
      })
    }

    if (req.url.indexOf('/form') !== -1) {
      fs.readFile('./form.html', (err, data) => {
        if (err) {
          res.writeHead(404)
          res.write('404 Not Found')
          res.end()

          return
        }

        res.writeHead(200)
        res.write(data)
        res.end()
      })
    } else if (req.url === '/') {
      fs.readFile('./index.html', (err, data) => {
        if (req.method === 'POST') {
          let queryData = ''

          req.on('data', function (data) {
            queryData += data
          })

          req.on('end', function () {
            let dataObj = qs.parse(queryData)
            let name = dataObj['name']
            let url = dataObj['url']

            if (name === undefined || url === undefined || name === '' || url === '') {
              res.writeHead(400)
              res.write(data)
              res.write('Name and url can\'t be empty')
              res.end()

              return
            }

            images.push(dataObj)
            res.writeHead(200, { 'StatusHeader': 'Full' })
            res.write(data)
            res.end()
          })
        } else {
          if (err) {
            res.writeHead(404)
            res.write('404 Not Found')
            res.end()

            return
          }

          res.writeHead(200)
          res.write(data)
          res.end()
        }
      })
    } else if (req.url.indexOf('/images') !== -1) {
      res.writeHead(200)
      res.write('<!doctype html>')
      res.write('<html>')
      res.write('<head>')
      res.write('<title>Images</title>')
      res.write('</head>')
      res.write('<body>')

      for (let i = 0; i < images.length; i++) {
        res.write('<p><a href="/images/details/' + i + '"><img src="' + images[i].url + '" width="200px" height="200px" /></a></p>')
      }

      res.write('<a href="/menu">Back</a>')
      res.write('</body>')
      res.write('</html>')
      res.end()
    } else if (req.url.indexOf('/images/details/') !== -1) {
      let splittedPath = req.url.split('/')
      let id = Number(splittedPath[3])
      let image = images[id]

      res.writeHead(200)
      res.write('<!doctype html>')
      res.write('<html>')
      res.write('<head>')
      res.write('<title>Images</title>')
      res.write('</head>')
      res.write('<body>')
      res.write('<img src="' + image.url + '" />')
      res.write('</body>')
      res.write('</html>')
      res.end()
    } else if (req.url.indexOf('/menu') !== -1) {
      fs.readFile('./menu.html', (err, data) => {
        if (err) {
          res.writeHead(404)
          res.write('404 Not Found')
          res.end()

          return
        }

        res.writeHead(200)
        res.write(data)
        res.end()
      })
    }
  })
  .listen(1500)
