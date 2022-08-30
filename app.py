from flask import Flask, jsonify, request
from flask_cors import CORS
import math
app = Flask(__name__)
CORS(app)


# main api call used to calculate string equation
# Requires json with calc key to be sent
# Returns solution: value of equation and history calculate string with = solution at the end
@app.route('/calculate', methods=['POST'])
def calculate():
    data = request.get_json()
    
    try:
        evaluated = str(eval(data['calc']))
        print(data["calc"]+ "=" + evaluated)
        json = jsonify({
                        'solution': evaluated,
                        'history': data["calc"] + "=" + evaluated,  
                        })
    except SyntaxError:
        json = jsonify({'solution': "ERROR"})
    return json


#Previous api calls that I didn't end up using'
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