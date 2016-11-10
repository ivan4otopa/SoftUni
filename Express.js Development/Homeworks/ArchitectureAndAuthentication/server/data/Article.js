let mongoose = require('mongoose')
let requiredValidationMessage = '{PATH} is required'
let articleSchema = mongoose.Schema({
  title: { type: String, required: requiredValidationMessage },
  content: { type: String, required: requiredValidationMessage },
  creationDate: { type: Date, default: Date.now },
  maker: { type: mongoose.Schema.Types.ObjectId, ref: 'User' }
})

module.exports = mongoose.model('Article', articleSchema)
