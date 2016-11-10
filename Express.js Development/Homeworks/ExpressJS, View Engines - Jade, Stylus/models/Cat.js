let mongoose = require('mongoose')
let catSchema = mongoose.Schema({
  name: String,
  age: Number,
  owner: { type: mongoose.Schema.Types.ObjectId, ref: 'Owner' }
})

module.exports = mongoose.model('Cat', catSchema)
