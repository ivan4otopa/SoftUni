let mongoose = require('mongoose')
let Tweet = require('../data/Tweet')
let User = require('../data/User')
let encryption = require('../utilities/encryption')

mongoose.Promise = global.Promise

module.exports = (config) => {
  mongoose
    .connect(config.db)
    // .then(() => {
    //   console.log('MongoDB up and running!')
    // })

  let db = mongoose.connection

  db.once('open', (err) => {
    if (err) {
      console.log(err)
    }

    console.log('MongoDB up and running!')

    db.on('error', (err) => {
      console.log('Database error: ', err)
    })
  })

  User
    .find()
    .then((users) => {
      if (users.length === 0) {
        let salt = encryption.generateSalt()
        let hashedPass = encryption.generateHashedPassword(salt, 'q')

        User
          .create({
            username: 'a',
            firstName: 'a',
            lastName: 'b',
            salt: salt,
            hashedPass: hashedPass,
            roles: ['Admin']
          })
          .then((user) => {
            let today = new Date()

            for (let i = 0; i < 200; i++) {
              let randomDate = new Date(today.getFullYear(), today.getMonth() + 1, today.getDate(), Math.random() * 23, Math.random() * 59, Math.random() * 59, Math.random() * 999)

              Tweet
                .create({
                  message: 'Message ' + i,
                  creationDate: randomDate,
                  author: user
                })
                .then((tweet) => {
                  User
                    .findByIdAndUpdate(user._id, { $push: { tweets: tweet } })
                    .exec()
                })
            }
          })
      }
    })
}
