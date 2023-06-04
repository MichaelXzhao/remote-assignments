function count(input) {
  return input.reduce((countObj, letter) => {
    countObj[letter] = (countObj[letter] || 0) + 1;
    return countObj;
  }, {});
}
let input1 = ["a", "b", "c", "a", "c", "a", "x"];
console.log(count(input1));
// should print {a:3, b:1, c:2, x:1}

function groupByKey(input) {
  return input.reduce((groupedObj, { key, value }) => {
    groupedObj[key] = (groupedObj[key] || 0) + value;
    return groupedObj;
  }, {});
}
let input2 = [
  { key: "a", value: 3 },
  { key: "b", value: 1 },
  { key: "c", value: 2 },
  { key: "a", value: 3 },
  { key: "c", value: 5 },
];
console.log(groupByKey(input2));
// should print {a:6, b:1, c:7}
