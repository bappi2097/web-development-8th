<?php

include_once "DBConfig.php";
class Crud extends DBConfig{
    public function __construct(){
        parent::__construct();
    }

    public function getData($query){
        $result = $this->connection->query($query);
        if(!$result){
            return false;
        }
            $rows = array();

            while($row = $result->fetch_assoc()){
                $rows[] = $row;
            }
        return $rows;
    }

    public function execute($query){
        $result = $this->connection->query($query);

        if($result == false){
            return false;
        }else{
            return true;
        }
    }

    public function delete($id, $table_name){
        $query = "delete from $table_name where id=$id";

        $result = $this->connection->query($query);

        if($result == false){
            return false;
        }else{
            return true;
        }
    }
}
?>