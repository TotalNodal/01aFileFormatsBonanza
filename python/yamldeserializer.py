import yaml

def deserialize_from_yaml(file_path):
    with open(file_path, 'r') as file:
        data = yaml.safe_load(file)
    return data

# Example usage
if __name__ == "__main__":
    yaml_file_path = "customer.yaml"

    # Deserialize data from YAML
    deserialized_data = deserialize_from_yaml(yaml_file_path)

    print("Data deserialized from YAML:")
    print(deserialized_data)