let http = require('http')
let port = 1000
let handlers = require('./handlers/index')

http
  .createServer((req, res) => {
    let hasBroke = false

    for (let handler of handlers) {
      let result = handler(req, res)

      if (!result) {
        hasBroke = true

        break
      }
    }

    if (!hasBroke) {
      res.writeHead(404)
      res.write('404 Not Found')
      res.end()
    }
  })
  .listen(port)

console.log(`Server listening on port ${port}...`)
