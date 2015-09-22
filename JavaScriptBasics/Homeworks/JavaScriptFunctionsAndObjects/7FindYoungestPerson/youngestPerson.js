var persons = [
    { firstname : 'George', lastname: 'Kolev', age: 32},
    { firstname : 'Bay', lastname: 'Ivan', age: 81},
    { firstname : 'Baba', lastname: 'Ginka', age: 40}];
function findYoungestPerson(persons) {
    var name = '';
    var youngest = 82;
    for(var i = 0; i < persons.length; i++) {
    	if(youngest > persons[i].age) {
    		youngest = persons[i].age;
    		name = persons[i].firstname + ' ' + persons[i].lastname;
    	}
    }
    console.log('The youngest person is ' + name);
}

findYoungestPerson(persons);