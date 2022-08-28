from flask import Flask, jsonify, request
import math
app = Flask(__name__)


@app.route('/', methods=['GET'])
def helloworld():
    return "hello world"


@app.route('/calculator/add', methods=['POST'])
def add():
    data = request.get_json()
    answer = float(data['Num1'])+float(data['Num2'])
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/subtract', methods=['POST'])
def subtract():
    data = request.get_json()
    answer = float(data['Num1'])/float(data['Num2'])
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/divide', methods=['POST'])
def divide():
    data = request.get_json()
    answer = float(data['Num1'])/float(data['Num2'])
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/multiply', methods=['POST'])
def multiply():
    data = request.get_json()
    answer = float(data['Num1'])*float(data['Num2'])
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/sqrt', methods=['POST'])
def sqrt():
    data = request.get_json()
    answer = math.sqrt(float(data['Num1']))
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/square', methods=['POST'])
def square():
    data = request.get_json()
    answer = float(data['Num1'])**2
    print(answer)
    return jsonify({'solution': answer})

@app.route('/calculator/exponent', methods=['POST'])
def exponent():
    data = request.get_json()
    answer = float(data['Num1'])**float(data['Num2'])
    print(answer)
    return jsonify({'solution': answer})



if __name__ == '__main__':
   app.run(debug=True)