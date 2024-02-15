def deserialize_from_txt(file_path):
    data = {}
    with open(file_path, 'r') as file:
        for line in file:
            key, value = map(str.strip, line.split(':', 1))
            data[key] = value
    return data

# Example usage
if __name__ == "__main__":
    # Specify the path for the text file
    txt_file_path = "customer.txt"

    # Deserialize data from the text file
    deserialized_data = deserialize_from_txt(txt_file_path)

    print("Data deserialized from TXT:")
    print(deserialized_data)