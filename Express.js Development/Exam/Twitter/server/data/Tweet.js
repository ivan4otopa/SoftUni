let mongoose = require('mongoose')
let requiredValidationMessage = '{PATH} is required'
let tweetSchema = mongoose.Schema({
  message: { type: String, required: requiredValidationMessage, maxlength: 140 },
  creationDate: { type: Date, default: Date.now() },
  viewsCount: { type: Number, default: 0 },
  likesCount: { type: Number, default: 0 },
  tags: [String],
  author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' }
})
let User = require('../data/User')

tweetSchema.pre('remove', function (next, req, callback) {
  User
    .findByIdAndUpdate(req.user._id, { $pull: { tweets: this._id, likedTweets: this._id } })
    .then((user) => {
      next()
    })
})

module.exports = mongoose.model('Tweet', tweetSchema)
