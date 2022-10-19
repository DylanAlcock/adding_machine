import {target} from '../setupProxy.js'


export async function getResponse() {
	const response = await fetch(target + '/api/AddingMachine');
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`); // handle errors
	}
	return await response.json(); // response
}

export async function postResponse(equation) {
		
	const response = await fetch(target + '/api/AddingMachine', {
		method: 'POST',
		body: JSON.stringify(equation),
		headers: {
			'Content-type': 'application/json; charset=UTF-8'
		}
    }
	);
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`); // handle errors
	}
	return await response.json(); // response
}

export async function deleteResponse() {

	const response = await fetch(target + '/api/AddingMachine', {
		method: 'DELETE'
		}
	);
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`); // handle errors
	}
	return await response.json(); // response
}
