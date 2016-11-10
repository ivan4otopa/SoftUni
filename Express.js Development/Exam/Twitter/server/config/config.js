let path = require('path')
let rootPath = path.normalize(path.join(__dirname, '../../'))
let connectionString = 'mongodb://localhost:27017/twitter'

module.exports = {
  development: {
    rootPath: rootPath,
    db: connectionString,
    port: 1000
  },
  production: {
    rootPath: rootPath,
    db: process.env.MONGODB_CONNECTION_STRING,
    port: process.env.port
  }
}
