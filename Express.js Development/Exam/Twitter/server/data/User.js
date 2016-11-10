let mongoose = require('mongoose')
let encryption = require('../utilities/encryption')
let requiredValidationMessage = '{PATH} is required'
let userSchema = mongoose.Schema({
  username: { type: String, required: requiredValidationMessage, unique: true },
  firstName: { type: String, required: requiredValidationMessage },
  lastName: { type: String, required: requiredValidationMessage },
  salt: String,
  hashedPass: String,
  roles: [String],
  tweets: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Tweet' }],
  likedTweets: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Tweets' }]
})

userSchema.method({
  authenticate: function (password) {
    let inputHashedPassword = encryption.generateHashedPassword(this.salt, password)

    return inputHashedPassword === this.hashedPass
  }
})

module.exports = mongoose.model('User', userSchema)
