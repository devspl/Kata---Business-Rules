(ns solution.payment)

(declare generate-packing-slip-stub)

(defn recieve-payment
  ([payment]
    (recieve-payment payment generate-packing-slip-stub))
  ([payment generate-packing-slip]
   (let
    [product (:product payment)
     type (:type product)]
    (when (= type :physical)
      (generate-packing-slip product)))))

(defn generate-packing-slip-stub
  "Sub function for packagin slip generation/save/send."
  []())