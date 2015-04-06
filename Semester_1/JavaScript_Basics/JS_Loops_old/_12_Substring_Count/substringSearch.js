/**
 * Created by isrmn on 16.3.2015 г..
 */
function countSubstringOccur(input) {
    var pattern = new RegExp(input[0].toLowerCase(), 'g');
    var text = input[1].toLowerCase();
    var count = (text.match(pattern) || []).length;
    console.log(count);
}
countSubstringOccur(['in', 'We are living in a yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']);
countSubstringOccur(['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.']);
countSubstringOccur(['but', 'But you were living in another world tryin\' to get your message through.']);