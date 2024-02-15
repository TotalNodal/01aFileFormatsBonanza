def serialize_to_txt(data, file_path):
    with open(file_path, 'w') as file:
        for key, value in data.items():
            file.write(f"{key}: {value}\n")

# Example usage
if __name__ == "__main__":
    # Example data to serialize
    data_to_serialize = {
        "FirstName": "John",
        "LastName": "Doe",
        "Address": "123 Example St"
    }

    # Specify the path for the text file
    txt_file_path = "customer.txt"

    # Serialize the data to a text file
    serialize_to_txt(data_to_serialize, txt_file_path)

    print(f"Data serialized to {txt_file_path}")