Function.prototype.extends = function  (parent) {
	this.prototype = Object.create(parent.prototype);
	this.prototype.constructor = this;
}

var Shapes = (function () {
	var Shape = (function () {
		function Shape (color) {
			this._color = color;
		}

		Shape.prototype.toString = function () {
			return ', color: ' + this._color;
		}

		return Shape;
	}());

	var Circle = (function () {
		function Circle (x, y, r, color) {
			Shape.call(this, color);
			this._x = x;
			this._y = y;
			this._r = r;
		}

		Circle.extends(Shape);

		Circle.prototype.toString = function () {
			return 'Circle: center point x: ' + this._x + ', center point y: ' + this._y  + ', radius: ' + this._r +
				Shape.prototype.toString.call(this);
		}

		return Circle;
	}());

	var Rectangle = (function () {
		function Rectangle (x, y, width, height, color) {
			Shape.call(this, color);
			this._x = x;
			this._y = y;
			this._width = width;
			this._height = height;
		}

		Rectangle.extends(Shape);

		Rectangle.prototype.toString = function () {
			return 'Rectangle: top left corner x: ' + this._x + ', top left corner y: ' + this._y + ', width: ' + this._width + ', height' +
				this._height + Shape.prototype.toString.call(this);
		}

		return Rectangle;
	}());

	var Triangle = (function () {
		function Triangle (x, y, a, b, c, d, color) {
			Shape.call(this, color);
			this._x = x;
			this._y = y;
			this._a = a;
			this._b = b;
			this._c = c;
			this._d = d;
		}

		Triangle.extends(Shape);

		Triangle.prototype.toString = function () {
			return 'Triangle: first point x: ' + this._x + ', first point y: ' + this._y + ', second point x: ' + this._a +
				', second point y: ' + this._b + ', third point x: ' + this._c + ', third point y: ' + this._d +
				Shape.prototype.toString.call(this);
		}

		return Triangle;
	}());

	var Line = (function () {
		function Line (x, y, a, b, color) {
			Shape.call(this, color);
			this._x = x;
			this._y = y;
			this._a = a;
			this._b = b;
		}

		Line.extends(Shape);

		Line.prototype.toString = function() {
			return 'Line: start point x: ' + this._x + ', start point y: ' + this._y + ', end point x: ' + this._a + ', end point y: ' +
				this._b + Shape.prototype.toString.call(this);
		};

		return Line;
	}());

	var Segment = (function () {
		function Segment (x, y, a, b, color) {
			Shape.call(this, color);
			this._x = x;
			this._y = y;
			this._a = a;
			this._b = b;
		}

		Segment.extends(Shape);

		Segment.prototype.toString = function() {
			return 'Segment: end point one x: ' + this._x + ', end point one y: ' + this._y + ', end point two x: ' + this._a +
				', end point two y: ' + this._b + Shape.prototype.toString.call(this);
		};

		return Segment;
	}());

	return {
		Circle: Circle,
		Rectangle: Rectangle,
		Triangle: Triangle,
		Line: Line,
		Segment: Segment
	}
}());

var circle = new Shapes.Circle(2, 4, 6, '#00FF00');
console.log(circle.toString());

console.log('---------------');

var rectangle = new Shapes.Rectangle(3, 7, 4, 9, '#AAFF00');
console.log(rectangle.toString());

console.log('---------------');

var triangle = new Shapes.Triangle(2, 5, 4, 9, 1, 6, '#DDBBAA');
console.log(triangle.toString());

console.log('---------------');

var line = new Shapes.Line(3, 8, 7, 4, '#0000BB');
console.log(line.toString());

console.log('---------------');

var segment = new Shapes.Segment(1, 9, 8, 4, '#FFFFAA');
console.log(segment.toString());