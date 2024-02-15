# Function to encode a string to UTF-8
def encode_to_utf8(input_string):
    encoded_bytes = input_string.encode('utf-8')
    return encoded_bytes

# Function to decode UTF-8 bytes to a string
def decode_from_utf8(encoded_bytes):
    decoded_string = encoded_bytes.decode('utf-8')
    return decoded_string

# Example usage
if __name__ == "__main__":
    # Example string to encode
    input_string = "Hello, 你好, привет!"

    # Encode the string to UTF-8
    encoded_data = encode_to_utf8(input_string)

    print(f"Encoded data: {encoded_data}")

    # Decode the UTF-8 bytes to a string
    decoded_string = decode_from_utf8(encoded_data)

    print(f"Decoded string: {decoded_string}")