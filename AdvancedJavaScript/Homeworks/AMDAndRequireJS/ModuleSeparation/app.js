require.config({
	factory: '../scripts/factory',
	listElement: '../scripts/listElement',
	Container: '../scripts/container',
	Section: '../scripts/section',
	Item: '../scripts/item'
});

require(['factory'], function (factory) {
	factory.addContainer('Tuesday TODO  List');
});