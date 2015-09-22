Object.prototype.extends = function(properties) {
	function f () {}
	var prop;

	f.prototype = Object.create(this);

	for(prop in properties) {
		f.prototype[prop] = properties[prop];
	}

	f.prototype._super = this;

	return new f();
};

var Shapes = (function () {
	var shape = {
		init: function (color) {
			this.color = color;

			return this;
		},

		toString: function () {
			return ', color: ' + this.color;
		}
	}

	var circle = shape.extends({
		init: function (x, y, r, color) {
			this._super.init.call(this, color);
			this.x = x;
			this.y = y;
			this.r = r;

			return this;
		},

		toString: function () {
			return 'Circle: center point x: ' + this.x + ', center point y: ' + this.y  + ', radius: ' + this.r +
				this._super.toString.call(this);
		}
	})

	var rectangle = shape.extends({
		init: function (x, y, width, height, color) {
			this._super.init.call(this, color);
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;

			return this;
		},

		toString: function () {
			return 'Rectangle: top left corner x: ' + this.x + ', top left corner y: ' + this.y + ', width: ' + this.width + ', height: ' +
				this.height + this._super.toString.call(this);
		}
	})

	var triangle = shape.extends({
		init: function (x, y, a, b, c, d, color) {
			this._super.init.call(this, color);
			this.x = x;
			this.y = y;
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;

			return this;
		},

		toString: function () {
			return 'Triangle: first point x: ' + this.x + ', first point y: ' + this.y + ', second point x: ' + this.a +
				', second point y: ' + this.b + ', third point x: ' + this.c + ', third point y: ' + this.d + this._super.toString.call(this);
		}
	})

	var line = shape.extends({
		init: function (x, y, a, b, color) {
			this._super.init.call(this, color);
			this.x = x;
			this.y = y;
			this.a = a;
			this.b = b;

			return this;
		},

		toString: function () {
			return 'Line: start point x: ' + this.x + ', start point y: ' + this.y + ', end point x: ' + this.a + ', end point y: ' +
				this.b + this._super.toString.call(this);
		}
	})

	var segment = shape.extends({
		init: function (x, y, a, b, color) {
			this._super.init.call(this, color);
			this.x = x;
			this.y = y;
			this.a = a;
			this.b = b;

			return this;
		},

		toString: function () {
			return 'Segment: end point one x: ' + this.x + ', end point one y: ' + this.y + ', end point two x: ' + this.a +
				', end point two y: ' + this.b + this._super.toString.call(this);
		}
	})

	return {
		circle: circle,
		rectangle: rectangle,
		triangle: triangle,
		line: line,
		segment: segment
	}
}());

var c = Object.create(Shapes.circle).init(3, 5, 2, '#0000FF');
console.log(c.toString());
console.log(c);

console.log('---------------');

var r = Object.create(Shapes.rectangle).init(1, 7, 6, 2, '#AA00FF');
console.log(r.toString());
console.log(r);

console.log('---------------');

var t = Object.create(Shapes.triangle).init(2, 8, 5, 9, 4, 7, '#AABBFF');
console.log(t.toString());
console.log(t);

console.log('---------------');

var l = Object.create(Shapes.line).init(6, 5, 7, 9, '#00BBFF');
console.log(l.toString());
console.log(l);

console.log('---------------');

var s = Object.create(Shapes.segment).init(3, 4, 8, 7, '#00BBAA');
console.log(s.toString());
console.log(s);