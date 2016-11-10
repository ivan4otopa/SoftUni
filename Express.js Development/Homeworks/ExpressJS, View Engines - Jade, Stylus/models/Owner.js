let mongoose = require('mongoose')
let ownerSchema = mongoose.Schema({
  name: String,
  cats: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Cat' }]
})
let Cat = require('./Cat')

ownerSchema.pre('remove', function (next) {
  Cat
    .remove({ owner: this._id })
    .exec()

  next()
})

module.exports = mongoose.model('Owner', ownerSchema)
