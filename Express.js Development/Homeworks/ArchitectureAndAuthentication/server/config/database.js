let mongoose = require('mongoose')
let User = require('../data/User')
let Article = require('../data/Article')
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
        let hashedPass = encryption.generateHashedPassword(salt, 'Admin12')

        User
          .create({
            username: 'Admin',
            firstName: 'Admin',
            lastName: 'Adminov',
            salt: salt,
            hashedPass: hashedPass,
            roles: ['Admin']
          })
          .then((user) => {
            for (let i = 0; i < 3; i++) {
              new Article({
                title: 'Title ' + i,
                content: 'Content ' + i,
                maker: user
              })
                .save()
                .then((article) => {
                  User
                    .findByIdAndUpdate(user._id, { $push: { articles: article } })
                    .exec()
                })
            }
          })
      }
    })
}
