import yaml

def serialize_to_yaml(data, file_path):
    with open(file_path, 'w') as file:
        yaml.dump(data, file, default_flow_style=False)

# Example usage
if __name__ == "__main__":
    # Example data to serialize
    data_to_serialize = {
        "person": {
            "FirstName": "John",
            "LastName": "Doe",
            "Address": "123 Example St"
        }
    }

    yaml_file_path = "customer.yaml"

    # Serialize the data to YAML
    serialize_to_yaml(data_to_serialize, yaml_file_path)

    print(f"Data serialized to {yaml_file_path}")