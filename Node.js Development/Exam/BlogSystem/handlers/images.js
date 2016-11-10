let fs = require('fs')
let url = require('url')

module.exports = (req, res) => {
  req.pathName = req.pathName || url.parse(req.url).pathname

  if (req.pathName.indexOf('/images') !== -1) {
    let splittedUrl = req.pathName.split('/')
    let imageName = splittedUrl[2]

    fs.readFile('./images/' + imageName, (err, data) => {
      if (err) throw err

      res.writeHead(200)
      res.write(data)
      res.end()
    })
  } else {
    return true
  }
}
